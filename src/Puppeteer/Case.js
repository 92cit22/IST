const puppeteer = require('puppeteer');
countVacancies();

async function countVacancies() {
    const browser = await puppeteer.launch({
        args: ['--start-maximized'],
        headless: false,
        slowMo: 100,
    });

    let page = await browser.pages().then(x => x[0]);
    await page.goto('https://careers.veeam.ru/vacancies');

    let opts = await page.$$("button#sl");

    await opts[0].click().then(x => {
        return clickElem("#root > div > div.container-main.container-fluid > div > div.row.block-spacer-top > div.col-12.col-lg-4 > div > div:nth-child(2) > div > div > div > a:nth-child(6)")
    })
    await opts[1].click().then(x => {
        return clickElem("#root > div > div.container-main.container-fluid > div > div.row.block-spacer-top > div.col-12.col-lg-4 > div > div:nth-child(3) > div > div > div > div:nth-child(1)")
    })

    page.$$("#root > div > div.container-main.container-fluid > div > div.row.block-spacer-top > div.col-12.col-lg-8 > div > a")
        .then(x => {
            if (x.length == 6) console.info(true)
            else console.error(false)
            browser.close()
        })

    async function clickElem(selector) {
        return page.waitForSelector(selector, { visible: true, hidden: false }).then(x => x.click())
    }
}