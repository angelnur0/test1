import puppeteer from "puppeteer";
import config from '../config/jestConfig';

let page;
let browser;
beforeAll(async () => {
  browser = await puppeteer.launch(config.puppeteerConf);
  page = await browser.newPage();
  await page.setViewport({ width: config.width, height: config.height });
});

afterAll(() => {
  browser.close();
});

describe("Login", () => {
  test("Login with incorrect data", async () => {
    await page.goto(config.appDefaultURl);
    await page.waitForSelector("input[id=loginform-username]");
    await page.waitForSelector("input[id=loginform-password]");
    await page.waitForSelector("button[name=login-button]");
  
    await page.click("input[id=loginform-username]");
    await page.type("input[id=loginform-username]", config.login.incorrect.login);
    await page.click("input[id=loginform-password]");
    await page.type("input[id=loginform-password]", config.login.incorrect.password);
    await page.click("button[name=login-button]");
    
    await page.waitForSelector('.alert-danger')
  }, config.defaultTimeout);
  
  test("Login with correct data", async () => {
    await page.goto(config.appDefaultURl);
    await page.waitForSelector("input[id=loginform-username]");
    await page.waitForSelector("input[id=loginform-password]");
    await page.waitForSelector("button[name=login-button]");
    
    await page.click("input[id=loginform-username]");
    await page.type("input[id=loginform-username]", config.login.correct.login);
    await page.click("input[id=loginform-password]");
    await page.type("input[id=loginform-password]", config.login.correct.password);
    await page.click("button[name=login-button]");
    
    await page.waitForSelector('.alert-success');
    await page.waitForSelector('.navbar');
    await page.waitForSelector('.quest-list');
  }, config.defaultTimeout);
});
