/*
 * @Author: 钟凯
 * @Date: 2021-02-25 14:17:14
 * @LastEditTime: 2021-02-25 22:48:45
 * @LastEditors: 钟凯
 * @Description:
 * @FilePath: \onework_manage_api\app\service\model\dataBehavior.js
 * @可以输入预定的版权声明、个性签名、空行等
 */
'use strict';

const Service = require('egg').Service;
const AppError = require('../../core/appError');

class DataBehaviorService extends Service {

  /**
   * @description: 添加数据模型行为
   * @param {*} 参数
   * @return {*}
   */
  async add(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    const DataBehaviorModel = ctx.model.Data.DataBehavior;
    // 验证所属数据模型是否正常
    const dataModel = await DataModel.findByPk(params.dataUid);
    if (dataModel) throw new AppError('该指定所属的数据模型数据不存在，无法进行添加！');
    // 验证名称是否重复
    let dataBehavior = await DataBehaviorModel.findOne({ where: { name: params.name, dataUid: dataModel.uid } });
    if (dataBehavior === null) throw new AppError(`该数据模型中行为“${params.name}”名称已存在，无法进行添加！`);
    // 验证参数
    await this._verifyParams(params);
    // 新增数据
    dataBehavior = {
      dataUid: dataModel.uid,
      name: params.name,
      code: params.code,
      inputs: params.inputs,
      outputs: params.outputs,
      operationType: params.operationType,
      description: params.description,
    };
    dataBehavior = await DataBehaviorModel.create(dataBehavior);
    // 返回结果
    return dataBehavior.dataValues;
  }

  /**
   * @description:
   * @param {*} pageParams
   * @param {*} queryParams
   * @return {*}
   */
  async query(pageParams, queryParams) {
    // 初始化参数
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    const DataBehaviorModel = ctx.model.Data.DataBehavior;
    const Op = ctx.app.Sequelize.Op;
    const queryParmas = {
      order: [[ 'id', 'desc' ]],
      offset: pageParams.limit * (pageParams.page - 1),
      limit: pageParams.limit,
      where: {},
    };
    // 排序
    const sort = pageParams.sort === ctx.app.appCode.common.order.desc ? 'DESC' : 'ASC';
    if (pageParams.order) {
      queryParmas.order = [[ pageParams.order, sort ]];
    }
    // 条件
    for (const key in queryParams) {
      if (Object.hasOwnProperty.call(queryParams, key)) {
        queryParmas.where[key] = queryParams[key];
      }
    }
    if (pageParams.keyword) {
      queryParmas.where = {
        ...queryParmas.where,
        [Op.or]: [
          { name: { [Op.substring]: pageParams.keyword } },
          { code: { [Op.substring]: pageParams.keyword } },
        ],
      };
    }
    // 查询
    const { count, rows } = await DataBehaviorModel.findAndCountAll(queryParmas);
    const datas = [];
    const modelUids = rows.map(t => t.uid);
    const models = await DataModel.findAll({ where: {
      uid: {
        [Op.in]: modelUids,
      },
    } });
    for (let i = 0; i < rows.length; i++) {
      const dataModel = rows[i].dataValues;
      const model = models.find(t => t.uid === dataModel.dataUid);
      if (model) {
        dataModel.dataName = model.name;
      }
      datas.push(dataModel);
    }
    return { total: count, rows: datas };
  }

  /**
   * @description:
   * @param {*} params
   * @return {*}
   */
  async update(params) {
    const ctx = this.ctx;
    const DataBehaviorModel = ctx.model.Data.DataBehavior;
    const Op = ctx.app.Sequelize.Op;
    // 验证所属数据是否存在
    const dataBehavior = await DataBehaviorModel.findByPk(params.uid);
    if (!dataBehavior) throw new AppError('该数据模型的行为不存在，无法进行修改！');
    // 验证名称是否重复
    const count = await DataBehaviorModel.findOne({ where: { name: params.name, dataUid: dataBehavior.dataUid, uid: {
      [Op.ne]: dataBehavior.uid,
    } } });
    if (count) throw new AppError(`该数据模型中行为“${params.name}”名称已存在，无法进行修改！`);
    // 验证参数
    await this._verifyParams(params);
    // 修改数据
    dataBehavior.name = params.name;
    dataBehavior.code = params.code;
    dataBehavior.inputs = params.inputs;
    dataBehavior.outputs = params.outputs;
    dataBehavior.operationType = params.operationType;
    dataBehavior.description = params.description;
    await dataBehavior.save();
    // 返回结果
    return dataBehavior.dataValues;
  }

  /**
   * @description:
   * @param {*} params
   * @return {*}
   */
  async remove(params) {
    const ctx = this.ctx;
    const DataBehaviorModel = ctx.model.Data.DataBehavior;
    const Op = ctx.app.Sequelize.Op;
    // 查询需要删除数据
    const datas = await DataBehaviorModel.findAll({ where: {
      uid: {
        [Op.in]: params,
      },
    } });
    if (params.length !== datas.length) { throw new AppError('删除数据中存在错误参数值，无法进行删除'); }
    // 删除数据
    for (let i = 0; i < datas.length; i++) {
      const element = datas[i];
      await element.destroy();
    }
  }

  /**
   * @description:
   * @param {*} params
   * @return {*}
   */
  async _verifyParams(params) {
    const ctx = this.ctx;
    const DataModel = ctx.model.Data.Data;
    // 验证输入
    if (params.inputs) {
      for (let i = 0; i < params.inputs.length; i++) {
        const input = params.inputs[i];
        if (input.itemType === ctx.app.appCode.model.itemType.array) {
          if (!input.arrayType) {
            throw new AppError('请填写输入参数中数组类型的具体类型');
          }
          if (input.arrayType === ctx.app.appCode.model.itemType.object) {
            if (!input.value) {
              throw new AppError('请填写输入参数中数组类型的对象应用类型');
            }
            const dataModel = await DataModel.findByPk({ where: {
              uid: input.value,
            } });
            if (dataModel == null) {
              throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
            }
          }
        }
        if (input.itemType === ctx.app.appCode.model.itemType.object) {
          if (!input.value) {
            throw new AppError('请填写输入参数中数组类型的对象应用类型');
          }
          const dataModel = await DataModel.findByPk({ where: {
            uid: input.value,
          } });
          if (dataModel == null) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
          }
        }
      }
    }
    // 验证输出
    if (params.outputs) {
      if (params.outputs.type === ctx.app.appCode.model.itemType.array) {
        if (params.outputs.arrayType === ctx.app.appCode.model.itemType.object) {
          if (!params.outputs.value) {
            throw new AppError('请填写输入参数中数组类型的对象应用类型');
          }
          const dataModel = await DataModel.findByPk({ where: {
            uid: params.outputs.value,
          } });
          if (dataModel == null) {
            throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
          }
        }
      }
      if (params.outputs.type === ctx.app.appCode.model.itemType.object) {
        if (!params.outputs.value) {
          throw new AppError('请填写输入参数中数组类型的对象应用类型');
        }
        const dataModel = await DataModel.findByPk({ where: {
          uid: params.outputs.value,
        } });
        if (dataModel == null) {
          throw new AppError('请填写该数据项对象类型中具体引用具体数据模型不存在');
        }
      }
    }
  }
}

module.exports = DataBehaviorService;
