function auto_grow(element) {
    element.style.height = "auto";
    element.style.height = (element.scrollHeight)+"px";
}
// fonction d'ajout d'input d'instruction
function addInstruction(type) {

    // appel de la fonction researchLastInstruction qui v�rifie et renvoi la derni�re instruction ou question
    var lastInstruction = researchLastInstruction();

    console.log(lastInstruction);
    // r�cup�re la span ou sera les �l�ments 
    var span = document.getElementById("SpanInstru");

    // cr�e une section qui sera envoyer dans la span SpanInstru
    var section = document.createElement("section")
    section.setAttribute('class', 'mb-3 row');

    // cr�e une div comprenant le label
    var divLabel = document.createElement("div");
    divLabel.setAttribute('class', 'col col-lg-2');
    // cr�e un label est l'ajoute � la divLabel
    var label = document.createElement("label");
    label.setAttribute('for', '');
    label.textContent = type;
    divLabel.appendChild(label);

    // cr�e une div comprenant le textarea
    var divInput = document.createElement("div");
    divInput.setAttribute('class', 'col-10')
    // cr�e un textarea est l'ajoute � la divInput
    var input = document.createElement("textarea");
    input.setAttribute('class', 'form-control test');
    input.setAttribute('name', type);
    input.setAttribute('rows', '1');
    input.setAttribute('oninput', 'auto_grow(this)');
    input.setAttribute('placeholder', 'ici doit tre inscrit le message  !');
    divInput.appendChild(input);

    // ajout les div � la section puis utilise append pour pr�ciser l'ordre
    section.appendChild(divLabel);
    section.appendChild(divInput);
    section.append(divLabel, divInput);

    // ajout la section dans la span 
    span.appendChild(section);
}

// r�cup�re tout les inputs d''instructio net de question et renvoi le dernier 
function researchLastInstruction() {
    // r�cup�re les input se trouvent dans la span SpanInstru
    var all = document.getElementsByClassName("test");
    return all;
    // 

}