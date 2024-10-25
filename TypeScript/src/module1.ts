export const name = "hello module01 is working now";

export function SayHello(tekst: string): string {
  console.log(name + " " + tekst);
  return SaySomeElse("via Hello " + " : " + tekst);
}

function SaySomeElse(tekst: string): string {
  console.log(name + " " + tekst);
  return "Say Iets Anders " + " : " + tekst;
}

export type mauricetype = number | boolean;
