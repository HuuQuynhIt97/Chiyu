const SYSTEM_CODE = 3;

export const environment = {
  production: true,
  systemCode: SYSTEM_CODE,
  apiUrlEC: 'http://10.4.4.224:80/api/',
  apiUrl: 'http://10.4.0.70:1018/api/',
  apiUrl2: 'http://10.4.0.70:1018/api/',
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
