const Fetch = require('./Fetch');

class Commands {
    constructor(bot){
        this.bot = bot
    }

    // IMPORTANT ! Tous les noms de méthode doivent être en minuscules excepté pour Commands.errorCmd()

    async getnews(msg){
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

    async errorCmd(msg) {
        msg.reply.text("Commande introuvable...")
    }

    async settings(msg){
        var AsciiTable = require('ascii-table')
        var settingsTable = new AsciiTable("Liste des paramètres")
        settingsTable
            .setHeading("Paramètre", "Valeur")
            .addRow("Notification", "true")

        this.bot.sendMessage(msg.chat.id, "`" + settingsTable.toString() + "`", {parseMode: 'markdown'})
    }
}

module.exports = Commands