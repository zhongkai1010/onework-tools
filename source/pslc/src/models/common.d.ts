/**
 * 排序方式
 *
 * @enum {number}
 */
enum Sort {
  Desc,
  Asc,
}

/**
 * 列表参数
 *
 * @export
 * @interface ListParams
 */
export interface ListParams {
  page: number;
  limit: number;
  order?: string;
  sort?: Sort;
}

/**
 * 响应错误
 *
 * @export
 * @interface ResponseError
 */
export interface ResponseError {
  message: string;
  code: string;
}

/**
 * 响应列表
 *
 * @export
 * @interface ResponseListResult
 * @template T
 */
export interface ResponseListResult<T> {
  total: number;
  data: Array<T>;
}

/**
 * 响应结果
 *
 * @export
 * @interface ResponseResult
 * @template T
 */
export interface ResponseResult<T> {
  result: T;
  success: boolean;
  error: ResponseError;
}
