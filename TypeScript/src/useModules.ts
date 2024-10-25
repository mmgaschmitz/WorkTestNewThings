import { name, SayHello } from "./module1.js";
import type { mauricetype } from "./module1.js";
// Kan niet, zelfde namen
// import { name, SayHello } from "./module2";
import { SaySomeElse } from "./module2.js";
SayHello(name);
SaySomeElse(name);

let a: mauricetype = true;
console.log(a);
