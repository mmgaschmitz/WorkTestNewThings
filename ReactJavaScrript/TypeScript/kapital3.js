// Unions
var mathematician = Math.random() > 0.5 ? 100.3455335 : "MAurice Schmitz";
console.log(typeof mathematician, mathematician, mathematician.toLocaleString);
if (typeof mathematician === "string") {
    console.log(mathematician.toLowerCase);
}
if (typeof mathematician === "number") {
    console.log(mathematician.toFixed(4));
}
// type Narrowing, nu is het type wel bekend.
var myvar;
myvar = "HelloWorld"; // NU is het type duidelijk
console.log(typeof myvar, myvar, myvar.toLocaleLowerCase());
myvar = 100;
console.log(typeof myvar, myvar, 
/* myvar.toLocaleLowerCase() , */
myvar.toLocaleString());
console.log(typeof myvar, myvar);
// Const
var DitIsAltijdZo = "Een waarde"; // uiteindelijk een string maar technische anders, hover over de variabele
console.log(typeof DitIsAltijdZo, DitIsAltijdZo);
myvar = undefined;
// union with const values
var GaatWel = "mijngaatwel";
var lifespan;
lifespan = 10;
console.log(typeof lifespan, lifespan);
lifespan = "ongoing";
console.log(typeof lifespan, lifespan);
lifespan = "uncertain";
console.log(typeof lifespan, lifespan);
// lifespan = "hello" //mag niet
lifespan = GaatWel;
console.log(typeof lifespan, lifespan);
lifespan = "mijngaatwel";
console.log(typeof lifespan, lifespan);
// null
// const firstName : string = null;  // kan in javascrip niet in typescript
var firstName = null;
// falsly check:
if (!firstName) {
    console.log(typeof firstName, firstName);
}
firstName = "Maurice";
if (!firstName) {
    console.log(typeof firstName, firstName);
}
