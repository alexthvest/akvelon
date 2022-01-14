module.exports = {
  roots: ["<rootDir>/tests"],
  transform: {
    "^.+\\.(ts|tsx)$": "<rootDir>/node_modules/babel-jest",
  },
  testMatch: ["<rootDir>/tests/**/*.{spec,test}.{ts,tsx}"],
  moduleDirectories: ["node_modules", "."],
  testEnvironment: "jest-environment-jsdom",
};
