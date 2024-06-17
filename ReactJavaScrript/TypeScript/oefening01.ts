// Javascript, let op foutmelding
//const firstName = "George";
//const nameLenght = firstName.length();

function sayMyName(fullName) {
  console.log(`- You acting kind of shady, ain't calling' me ${fullName} `);
}

// sayMyName("Beyoncé", "Knowles");
sayMyName("Beyoncé");

// voorbeeld:
interface Material {
  color: string;
  Kenmerk1: number;
  KennmerkB: string;
}

interface Painter {
  finish(): boolean;
  ownMaterials: Material[];
  paint(painting: string, materials: Material[]): boolean;
}

//using
function paintPainting(painter: Painter, painting: string): boolean {
  return painter.paint(painting, painter.ownMaterials);
}
