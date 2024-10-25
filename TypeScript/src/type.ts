let singer = "Aretha";
console.log("Var: " + singer + ", Type: " + typeof singer);

{
  // Fout
  // console.log("Var: " + singer + ", Type: " + typeof singer);
  let singer = "is ook al bekend";
  console.log("Var: " + singer + ", Type: " + typeof singer);

  // Fout
  //  console.log("Var: " + singer2 + ", Type: " + typeof singer2);
  let singer2: string = "bekend gemaakt";
  console.log("Var: " + singer2 + ", Type: " + typeof singer2);
}
let singer2: string = "Aretha";
console.log("Var: " + singer2 + ", Type: " + typeof singer2);

// var alleen function scopy
// let blok scope,
var singer3 = "Aretha";
console.log("Var: " + singer3 + ", Type: " + typeof singer3);

Maurice();

{
  let singer2 = "blocked scopy"; // bestond buiten het blok is hier een nieuwe
  console.log(singer3); // singer3 als var bestond al file level.
  var singer3 = "bekend";
  console.log(singer3);

  // console.log(singer4); // Variabele bestaat nog niet
  var singer4: string = "onbekend";
  console.log(singer4);
}

Maurice();

var singer4: string = "Aretha";
console.log("Var: " + singer4 + ", Type: " + typeof singer4);

function Maurice() {
  var singer3 = "Aretha";
  console.log("Var: " + singer3 + ", Type: " + typeof singer3);

  var singer4: string = "Aretha";
  console.log("Var: " + singer4 + ", Type: " + typeof singer4);
}

// Let op bij const is het van het type van de waarde, maar in javascipt nog altijd een string
const asinger = "Hello";
console.log("Var: " + asinger + ", Type: " + typeof asinger);

let asinger2: string = "naam";
// fout: m een error
// asinger2 = 123;
// fout:
// asinger2 = true;
asinger2 = "naam2";

let asinger3: string | boolean = "naam";
// fout:
// asinger3 = 123;
// fout:
asinger3 = true;

//
// Narrowing
//
let itCanbe = Math.random() > 0.5 ? "maurice" : 25;

if (typeof itCanbe === "number") {
  // verander het type
  let a = itCanbe / 3;
  console.log(a);
}

if (typeof itCanbe === "string") {
  let a = itCanbe.toLowerCase();
  console.log(a);
}

// why ===

let num: number = 10;
let str: string = "10";
num = 10;
str = "10";

// console.log(num == str); // true - The values are the same after type conversion
//  console.log(num === str);

let bool = true;
bool = true;
console.log(num, str, bool);
console.log(asinger, asinger2, asinger3);
