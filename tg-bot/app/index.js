const TeleBot = require('telebot');
const secrets = require('./secrets.json');
const bot = new TeleBot(secrets.BOT_TOKEN);

bot.on('/bonjour', (msg) => msg.reply.text(`Bonjour ${msg.from.username}`));

bot.on('/bonsoir', (msg) => msg.reply.text(`Bonsoir ${msg.from.username}`));

bot.start();