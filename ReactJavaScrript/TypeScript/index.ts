/*
npm i -D tsx
npx tsx ./index.ts

tsc *.ts
*/

import { cher, myOveral } from "./module01";

console.log("Hello World");
console.log("Hello World 2 times");

// variabel:
let singer = "Artetha";
let jaar = 1941;
// let grootgetal = 443566n;  // problem
let grootdecimal = 8736724674682764237843543453453453232443566.345743537835;
let IsKeuze = true;
let leeg = null;
let leeg2 = undefined;

// Fouten
// singer = 10;
// jaar = "hELLO";

console.log(singer, jaar, grootdecimal, IsKeuze, leeg, leeg2);

console.log(singer.toLowerCase());
singer = singer.replace("a", "b");
console.log(singer.toLocaleUpperCase());

// any
let kanVanAllesZijn: any;

kanVanAllesZijn = 100;
console.log(kanVanAllesZijn);

kanVanAllesZijn = "hello";
console.log(kanVanAllesZijn);

// Overbodige info:
let firstName: string = "Tina";
console.log(firstName);

//complexer type cher imported via module

console.log(cher.firstName);
console.log(cher.lastName);

console.log(myOveral);
