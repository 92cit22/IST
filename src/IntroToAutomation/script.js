 
const puppeteer = require('puppeteer'); 
 
async function testTaxiResult() {
 
    console.log('Запуск браузера');
    const browser = await puppeteer.launch({
        headless: false,
        slowMo: 100,
    });
 
    // тестов ещё нет
 
    console.log('Закрытие браузера');
    await browser.close();
}
 
testTaxiResult(); 
