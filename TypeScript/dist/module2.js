const name = "hello module01";
function SayHello(tekst) {
    console.log(tekst);
    return SaySomeElse("via Hello " + tekst);
}
function SaySomeElse(tekst) {
    console.log(tekst);
    return "Say Iets Anders " + tekst;
}
// Nieuwere manier
export { name, SayHello };
//# sourceMappingURL=module2.js.map