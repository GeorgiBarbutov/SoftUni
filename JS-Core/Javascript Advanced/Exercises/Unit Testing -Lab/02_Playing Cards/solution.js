function makeCard(face, suit){
    let allowedFaces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
    let allowedSuits = {
        'S': '\u2660', 
        'H': '\u2665', 
        'D': '\u2666', 
        'C': '\u2663'
    };
    
    if(!allowedFaces.includes(face) || !Object.keys(allowedSuits).includes(suit)){
        throw new Error('Error');
    }

    let card = {
        face: face, 
        suit: allowedSuits[suit],
        toString: function(){
            return '' + this.face + this.suit;
        }
    };

    return card;
}

console.log(makeCard('A', 'H').toString());
