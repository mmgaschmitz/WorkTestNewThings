const name = "hello module01";

function SayHello(tekst: string): string {
  console.log(tekst);
  return SaySomeElse("via Hello " + tekst);
}

function SaySomeElse(tekst: string): string {
  console.log(tekst);
  return "Say Iets Anders " + tekst;
}

// Nieuwere manier
export { name, SayHello };
