"use strict";
/*
npm i -D tsx
npx tsx ./index.ts

tsc *.ts
*/
Object.defineProperty(exports, "__esModule", { value: true });
var module02_1 = require("./module02");
console.log("Hello World");
console.log("Hello World 2 times");
// variabel:
var singer = "Artetha";
var jaar = 1941;
// let grootgetal = 443566n;  // problem
var grootdecimal = 8736724674682764237843543453453453232443566.345743537835;
var IsKeuze = true;
var leeg = null;
var leeg2 = undefined;
// Fouten
// singer = 10;
// jaar = "hELLO";
console.log(singer, jaar, grootdecimal, IsKeuze, leeg, leeg2);
console.log(singer.toLowerCase());
singer = singer.replace("a", "b");
console.log(singer.toLocaleUpperCase());
// any
var kanVanAllesZijn;
kanVanAllesZijn = 100;
console.log(kanVanAllesZijn);
kanVanAllesZijn = "hello";
console.log(kanVanAllesZijn);
// Overbodige info:
var firstName = "Tina";
console.log(firstName);
//complexer type cher imported via module
console.log(module02_1.cher.firstName);
console.log(module02_1.cher.lastName);
// console.log(myOveral);
