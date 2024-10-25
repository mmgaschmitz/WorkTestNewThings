const philosopher = "Hypatia"; // type is Hypatia
console.log(
  "Var philosopher: " + philosopher + ", Type: " + typeof philosopher
);

// philosopher = "Tuup";

let lifespan: number | "ongoing" | "uncertain";

lifespan = 10;
console.log("Var lifespan: " + lifespan + ", Type: " + typeof lifespan);

lifespan = "ongoing";
console.log("Var lifespan: " + lifespan + ", Type: " + typeof lifespan);

lifespan = "uncertain";
console.log("Var lifespan: " + lifespan + ", Type: " + typeof lifespan);

// nog een
let specificallyAda: "Ada";
// specificallyAda = "sdfss"
specificallyAda = "Ada";
console.log(
  "Var specificallyAda: " +
    specificallyAda +
    ", Type: " +
    typeof specificallyAda
);
