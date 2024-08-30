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
  var singer3 = "bekend";
  var singer4: string = "onbekend";
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
