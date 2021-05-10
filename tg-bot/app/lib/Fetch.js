const nodeFetch = require('node-fetch');
class Fetch {
    static async getJson(url){
        var jsonString = await(await nodeFetch(url)).json()
        var jsonObj = JSON.parse(jsonString);
        return jsonObj;
    }
}
module.exports = Fetch