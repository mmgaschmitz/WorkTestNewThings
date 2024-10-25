const name = "hello module02";

function SayHello(tekst: string): string {
  console.log(name + " " + tekst);
  return SaySomeElse("via Hello " + name + " : " + tekst);
}

function SaySomeElse(tekst: string): string {
  console.log(name + " " + tekst);
  return "Say Iets Anders " + name + " : " + tekst;
}

// Nieuwere manier
export { name, SayHello, SaySomeElse };
