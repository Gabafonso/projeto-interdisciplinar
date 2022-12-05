const button = document.querySelector('.login__button');
const form = document.querySelector('.login-form');
const players = document.querySelectorAll('.player');
const text = document.querySelector('.text');
const images = document.querySelectorAll('.image');
let nome = '';

const handleSubmit = (event) => {
    event.preventDefault();

    localStorage.setItem('player', nome);
    window.location = 'interJump.html';
}

function resetPlayer(){
    for (let i = 0; i < images.length; i++){
        images[i].classList.remove("active");
    }
}

const ChoosePlayer = (event) => {
    event.preventDefault();
    
    nome = event.target.getAttribute('alt');
    text.innerHTML = nome;
    resetPlayer();
    

    //text.innerHTML = event.target;
    //text.innerHTML = event.target.getAttribute('alt');
    //text.innerHTML = 'Quer escolher <img src=' + event.target.getAttribute('src') + '> como Pokémon inicial?';
    //'Quer escolher <img src="../images/sprites/pokemon/' + 1 + '.png"> como Pokemon inicial?'   
    //text.innerHTML += document.querySelector("."+nome).getAttribute('alt');
    document.querySelector("."+nome).classList.add("active");

    button.removeAttribute('disabled');
}


form.addEventListener('submit', handleSubmit);
players.forEach((player) => player.addEventListener('click', ChoosePlayer));