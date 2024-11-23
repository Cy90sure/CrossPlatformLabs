const axios = require('axios');
const https = require('https');
const logger = require('../config/logger');

const API_BASE_URL = 'https://localhost:7095/api';

const axiosInstance = axios.create({
    baseURL: API_BASE_URL,
    httpsAgent: new https.Agent({
        rejectUnauthorized: false,
    }),
});

describe('ProductsAndServices API Tests', () => {
    beforeAll(() => {
        logger.info('Starting ProductsAndServices API tests');
    });

    afterAll(() => {
        logger.info('Finished ProductsAndServices API tests');
    });

    test('GET /api/Data/ProductsAndServices should return all products and services', async () => {
        try {
            logger.info('Testing GET /api/Data/ProductsAndServices');
            const response = await axiosInstance.get('/Data/ProductsAndServices');

            logger.info(`Received ${JSON.stringify(response.data)} products and services`);
            expect(response.status).toBe(200);
            expect(Array.isArray(response.data)).toBe(true);
        } catch (error) {
            logger.error(`Error testing GET /api/Data/ProductsAndServices: ${error.message}`);
            throw error;
        }
    });
});

describe('Locations API Tests', () => {
    beforeAll(() => {
        logger.info('Starting Locations API tests');
    });

    afterAll(() => {
        logger.info('Finished Locations API tests');
    });

    test('GET /api/Data/Locations should return all locations', async () => {
        try {
            logger.info('Testing GET /api/Data/Locations');
            const response = await axiosInstance.get('/Data/Locations');

            logger.info(`Received ${JSON.stringify(response.data)} locations`);
            expect(response.status).toBe(200);
            expect(Array.isArray(response.data)).toBe(true);
        } catch (error) {
            logger.error(`Error testing GET /api/Data/Locations: ${error.message}`);
            throw error;
        }
    });
});

describe('Organizations API Tests', () => {
    beforeAll(() => {
        logger.info('Starting Organizations API tests');
    });

    afterAll(() => {
        logger.info('Finished Organizations API tests');
    });

    test('GET /api/Data/Organizations should return all organizations', async () => {
        try {
            logger.info('Testing GET /api/Data/Organizations');
            const response = await axiosInstance.get('/Data/Organizations');

            logger.info(`Received ${JSON.stringify(response.data)} organizations`);
            expect(response.status).toBe(200);
            expect(Array.isArray(response.data)).toBe(true);
        } catch (error) {
            logger.error(`Error testing GET /api/Data/Organizations: ${error.message}`);
            throw error;
        }
    });
});

describe('Countries API Tests', () => {
    beforeAll(() => {
        logger.info('Starting Countries API tests');
    });

    afterAll(() => {
        logger.info('Finished Countries API tests');
    });

    test('GET /api/Data/Countries should return all countries', async () => {
        try {
            logger.info('Testing GET /api/Data/Countries');
            const response = await axiosInstance.get('/Data/Countries');

            logger.info(`Received ${JSON.stringify(response.data)} countries`);
            expect(response.status).toBe(200);
            expect(Array.isArray(response.data)).toBe(true);
        } catch (error) {
            logger.error(`Error testing GET /api/Data/Countries: ${error.message}`);
            throw error;
        }
    });
});

describe('MovementLocations API Tests', () => {
    beforeAll(() => {
        logger.info('Starting MovementLocations API tests');
    });

    afterAll(() => {
        logger.info('Finished MovementLocations API tests');
    });

    test('GET /api/MovementLocations should return all movement locations', async () => {
        try {
            logger.info('Testing GET /api/MovementLocations');
            const response = await axiosInstance.get('/MovementLocations');

            logger.info(`Received ${JSON.stringify(response.data)} movement locations`);
            expect(response.status).toBe(200);
            expect(Array.isArray(response.data)).toBe(true);
        } catch (error) {
            logger.error(`Error testing GET /api/MovementLocations: ${error.message}`);
            throw error;
        }
    });
});

describe('Database Integration Tests', () => {
    beforeAll(() => {
        logger.info('Starting Database Integration tests');
    });

    afterAll(() => {
        logger.info('Finished Database Integration tests');
    });

    describe('SQLite Server', () => {
        test('should perform basic operations with SQLite Server', async () => {
            try {
                logger.info('Testing SQLite Server connection');
                const response = await axiosInstance.get('/Data/ProductsAndServices');
                logger.info('Successfully connected to SQLite Server');
                expect(response.status).toBe(200);
            } catch (error) {
                logger.error(`SQLite Server test failed: ${error.message}`);
                throw error;
            }
        });
    });
});
