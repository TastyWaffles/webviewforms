export {};

declare global {
  interface Window {
    chrome: {
      webview: {
        postMessage: (message: any) => void;
      };
    };
  }
}
