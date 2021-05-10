const Fetch = require('./Fetch');
class Commands {
    constructor(bot){
        this.bot = bot
    }

    toto(){
        console.log("toto");
    }
    async getNews(msg){
        var jsonObj = await Fetch.getJson("https://localhost:44388/api/news");
        var items = jsonObj.rss.channel.item;
        var message = "";
        items.forEach(element => {
            message += element.link + "\n"
        });
        msg.reply.text(message)
    }

    async notification(msg){
        var notification = true;
        notification = notification == true ? false : true;
        return notification ? msg.reply.text("Les notifications ont été activées !") : msg.reply.text("Les notifications ont été désactivées !");
    }

    async start(msg){
        msg.reply.text("Bienvenue !")
    }

    async toto(msg){
        console.log("TOTOTUTU");
        msg.reply.text("toto reverse !")
    }
    
    async tata(){
        console.log("TATATUTU");
    }
    async titi(){
        console.log("TITI");
    }

    async lol(){
        console.log("TITI");
    }
}

module.exports = Commands