var totalInstruction = 0;
var totalQuestion = 0;

function auto_grow(element) {
    element.style.height = "auto";
    element.style.height = (element.scrollHeight)+"px";
}
// fonction d'ajout d'input d'instruction
function addInstruction(type) {

    // appel de la fonction researchLastInstruction qui v�rifie et renvoi la derni�re instruction ou question puis cr�ation d'une variable name reprenent le type et sont num�ro  
    var lastInstruction = researchLastInstruction(type);
    var name = type + " " + lastInstruction;

    // r�cup�re la span ou sera les �l�ments 
    var span = document.getElementById("SpanInstru");

    // cr�e une section qui sera envoyer dans la span SpanInstru
    var section = document.createElement("section")
    section.setAttribute('class', 'mb-3 row SectionInstru');
    section.setAttribute('id', name);

    // cr�e une div comprenant le label
    var divLabel = document.createElement("div");
    divLabel.setAttribute('class', 'col col-lg-2 m-auto');
    // cr�e une icone est l'ajoute � la divInput
    var icon = document.createElement("i");
    icon.setAttribute('class', 'fas fa-indent h-100 w-5 me-3');
    icon.setAttribute('name', name);
    divLabel.appendChild(icon);

    // cr�e un label est l'ajoute � la divLabel
    var label = document.createElement("label");
    label.setAttribute('for', type);
    label.textContent = type;
    divLabel.appendChild(label);

    // cr�e une div comprenant le textarea
    var divInput = document.createElement("div");
    divInput.setAttribute('class', 'col-10 d-inline-flex');
    
    var inputHidden = document.createElement("input");
    inputHidden.setAttribute('type', 'hidden');
    inputHidden.setAttribute('name', 'Types');
    inputHidden.setAttribute('value', type);
    divInput.appendChild(inputHidden);

    // cr�e un textarea est l'ajoute � la divInput
    var input = document.createElement("textarea");
    input.setAttribute('class', 'form-control');
    input.setAttribute('rows', '1');
    input.setAttribute('name', 'Messages');
    input.setAttribute('oninput', 'auto_grow(this)');
    input.setAttribute('placeholder', 'ici doit etre inscrit le message  !');
    divInput.appendChild(input);

    // crée une icone est l'ajoute � la divInput
    var icon = document.createElement("i");
    icon.setAttribute('class', 'fas fa-times-circle text-danger h-100 w-5 ms-3');
    icon.setAttribute('name', name);
    icon.setAttribute('onclick', "deleteInput('"+ name +"')");
    divInput.appendChild(icon);

    // ajout les div � la section puis utilise append pour pr�ciser l'ordre
    section.appendChild(divLabel);
    section.appendChild(divInput);
    section.append(divLabel, divInput);

    // ajout la section dans la span 
    span.appendChild(section);
}

// r�cup�re tout les inputs d''instructio net de question et renvoi le dernier 
function researchLastInstruction(type) {
    // r�cup�re les input se trouvent dans la span SpanInstru
    if (type == 'Instruction') {
        totalInstruction += 1;
        return totalInstruction;
    }
    else {
        totalQuestion += 1;
        return totalQuestion;
    }
}

function deleteInput(name) {
    var InputDelete = document.getElementById(name);
    InputDelete.parentNode.removeChild(InputDelete);
    //changeInstru(name);
}

//function changeInstru(nameInstru) {

//    if (nameInstru.name.includes('Instruction'){
    
//}
//    var all = document.getElementsByClassName("SectionInstru");
    


//    //Array.from(all).forEach(element => {
//    //    if (element.name.includes('Instruction')) {
//    //        totalInstruction += 1;
//    //    }
//    //    else {
//    //        totalQuestion += 1;
//    //    }
//    //})
//}