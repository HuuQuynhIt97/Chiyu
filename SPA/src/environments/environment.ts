// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

const SYSTEM_CODE = 3;

export const environment = {
  production: false,
  systemCode: SYSTEM_CODE,
  apiUrlEC: 'http://10.4.4.224:80/api/',
  // apiUrl: 'http://10.4.0.70:1018/api/',
  // apiUrl2: 'http://10.4.0.70:1018/api/',
  apiUrl: 'http://10.4.5.132:1018/api/',
  apiUrl2: 'http://10.4.5.132:1018/api/',
  hub: 'http://10.4.4.224:80/ec-hub',
  scalingHub: 'http://10.4.4.224:80/ec-hub',
  scalingHubLocal: 'http://localhost:5001/scalingHub',

  _mqtt: {
    server: 'mqtt.myweb.com',
    protocol: "wss",
    port: 1883
  },
  get mqtt() {
    return this._mqtt;
  },
  set mqtt(value) {
    this._mqtt = value;
  },
};


