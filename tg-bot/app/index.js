const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);

const Fetch = require('./lib/Fetch');
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = 0

var notification = true;


bot.on('/bonjour', (msg) => msg.reply.text(`Bonjour ${msg.from.username}`));

bot.on('/bonsoir', (msg) => msg.reply.text(`Bonsoir ${msg.from.username}`));

// Return last news from Tom's Hardware fr RSS flow
bot.on('/getNews', async (msg) => {
    var jsonObj = await Fetch.getJson("https://localhost:44388/api/news");
    var items = jsonObj.rss.channel.item;
    var message = "";
    items.forEach(element => {
      message += element.link + "\n"
    });
    msg.reply.text(message)
});

bot.on('/notification', function(msg) {
    notification = notification == true ? false : true;
    return notification ? msg.reply.text("Les notifications ont été activées !") : msg.reply.text("Les notifications ont été désactivées !");
});

bot.start();
