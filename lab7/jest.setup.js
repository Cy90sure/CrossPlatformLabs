const fs = require('fs');
const path = require('path');
const logger = require('./config/logger');

const logsDir = path.join(__dirname, 'logs');
if (!fs.existsSync(logsDir)) {
    fs.mkdirSync(logsDir);
}

beforeAll(() => {
    logger.info('Starting test suite execution');
});

afterAll(() => {
    logger.info('Finished test suite execution');
});

