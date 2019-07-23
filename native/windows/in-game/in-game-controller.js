define([
  '../../scripts/constants/window-names.js',
  '../../scripts/services/launch-source-service.js',
  '../../scripts/services/running-game-service.js',
  '../../scripts/services/windows-service.js',
  '../../scripts/services/hotkeys-service.js',
  '../../windows/in-game/in-game-view.js'
], function (WindowNames,
             launchSourceService,
             runningGameService,
             windowsService,
             hotkeysService,
             InGameView) {

  class InGameController {

    static run() {
      const desktopView = new InGameView();
      // listen to events from the event bus from the main window,
      // the callback will be run in the context of the current window
      let mainWindow = overwolf.windows.getMainWindow();
      mainWindow.ow_eventBus.addListener(InGameController._eventListener);
    }

    static _eventListener(eventName, data) {
      switch (eventName) {
        case '': {
          break;
        }
        default:
          break;
      }
    }
  }


  return InGameController;
});