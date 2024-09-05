export const name = "hello module01";

export function SayHello(tekst: string): string {
  console.log(tekst);
  return SaySomeElse("via Hello " + tekst);
}

function SaySomeElse(tekst: string): string {
  console.log(tekst);
  return "Say Iets Anders " + tekst;
}

export type mauricetype = number | boolean;
