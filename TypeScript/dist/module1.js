export const name = "hello module01";
export function SayHello(tekst) {
    console.log(tekst);
    return SaySomeElse("via Hello " + tekst);
}
function SaySomeElse(tekst) {
    console.log(tekst);
    return "Say Iets Anders " + tekst;
}
//# sourceMappingURL=module1.js.map