let package = {
  /**
   * 初始化插件
   */
  init: () => {
    chrome.runtime.onInstalled.addListener(function (params) {
      console.log("runtime.onInstalled", params);
      //package.createContextMenus();
      // chrome.storage.local.set({ request_records: [] });
    });
    chrome.history.onVisited.addListener(function (params) {
      console.log("history.onVisited", params);
      // chrome.storage.local.get(["request_records"], function (result) {
      //   console.log("request_records", result);
      //   result.request_records.push(requestRecord.title);
      //   chrome.storage.local.set(result);
      // });
    });
    chrome.webNavigation.onCompleted.addListener(function (params) {
      console.log("webNavigation.onCompleted", params);
    });
  },
  /**
   * 创建右键菜单
   */
  createContextMenus: () => {
    chrome.contextMenus.create({
      id: "sampleContextMenu",
      title: "Sample Context Menu",
    });
    chrome.contextMenus.onClicked.addListener(function () {
      alert("1");
    });
  },
};
(function (startp) {
  startp.init();
})(package);
