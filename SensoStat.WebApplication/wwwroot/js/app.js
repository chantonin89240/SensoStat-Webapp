function auto_grow(element) {
    element.style.height = "auto";
    element.style.height = (element.scrollHeight)+"px";
}
// fonction d'ajout d'input d'instruction
function addInstruction(type) {

    // appel de la fonction researchLastInstruction qui vérifie et renvoi la dernière instruction ou question puis création d'une variable name reprenent le type et sont numéro  
    var lastInstruction = researchLastInstruction(type);
    var name = type + lastInstruction;

    // récupére la span ou sera les éléments 
    var span = document.getElementById("SpanInstru");

    // crée une section qui sera envoyer dans la span SpanInstru
    var section = document.createElement("section")
    section.setAttribute('class', 'mb-3 row');

    // crée une div comprenant le label
    var divLabel = document.createElement("div");
    divLabel.setAttribute('class', 'col col-lg-2');
    // crée un label est l'ajoute à la divLabel
    var label = document.createElement("label");
    label.setAttribute('for', type);
    label.textContent = name;
    divLabel.appendChild(label);

    // crée une div comprenant le textarea
    var divInput = document.createElement("div");
    divInput.setAttribute('class', 'col-10')
    // crée un textarea est l'ajoute à la divInput
    var input = document.createElement("textarea");
    input.setAttribute('class', 'form-control ChampInstru');
    input.setAttribute('rows', '1');
    input.setAttribute('name', type);
    input.setAttribute('oninput', 'auto_grow(this)');
    input.setAttribute('placeholder', 'ici doit etre inscrit le message  !');
    divInput.appendChild(input);

    // ajout les div à la section puis utilise append pour préciser l'ordre
    section.appendChild(divLabel);
    section.appendChild(divInput);
    section.append(divLabel, divInput);

    // ajout la section dans la span 
    span.appendChild(section);
}

// récupére tout les inputs d''instructio net de question et renvoi le dernier 
function researchLastInstruction(type) {
    // récupére les input se trouvent dans la span SpanInstru
    var all = document.getElementsByClassName("ChampInstru");
    var totalInstruction = 0;
    var totalQuestion = 0;

    Array.from(all).forEach(element => {
        if (element.name.includes('Instructions')) {
            totalInstruction += 1;
        }
        else {
            totalQuestion += 1;
        }
    })

    if (type == 'Instructions') {
        totalInstruction += 1;
        return totalInstruction;
    }
    else {
        totalQuestion += 1;
        return totalQuestion;
    }
}