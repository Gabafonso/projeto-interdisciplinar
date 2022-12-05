const avatar = document.querySelector('.avatar');
const pipe = document.querySelector('.pipe');
const timer = document.querySelector('.timer');
var root = document.documentElement;

let name = localStorage.getItem('player');
name = '../images/interJump/' + name + '.png';

avatar.setAttribute('src', name)

const loop = setInterval(() => {

    const pipePosition = pipe.offsetLeft;
    // const pipeMovement = pipe.offsetRight;
    const avatarPosition = +window.getComputedStyle(avatar).bottom.replace('px', '');
    
    // if (pipePosition > 0){
    //     root.style.setProperty('--animacao1', pipeMovement+'px');
    //     root.style.setProperty('--animacao2', pipeMovement+10+'px');
    // }

    temporizador

    if (pipePosition <= 75 && pipePosition > 0 && avatarPosition < 100) {

        pipe.style.animation = 'none';
        pipe.style.left = `${pipePosition}px`;

        avatar.style.animation = 'none';
        avatar.style.bottom = `${avatarPosition}px`;

        avatar.classList.add("morto");
        //avatar.src = name;
        // avatar.style.width = '75px'
        // avatar.style.marginLeft = '50px';

        clearInterval(loop);
        clearInterval(temporizador);
    }

}, 10)

const jump = () => {
    const avatarPosition = +window.getComputedStyle(avatar).bottom.replace('px', '');
    if (avatarPosition == 0){
        avatar.classList.add('jump');
        
        setTimeout(() => {
            
            avatar.classList.remove('jump');
            
        }, 500);
    }
}

const fall = () =>{

}

//document.addEventListener('keydown', jump);
document.onkeydown = function(key){
    if (key.key == 'ArrowUp' || key.key == ' '){
        jump();
    }
    if (key.key == 'ArrowDown'){
        fall();
    }
}

const temporizador = setInterval(() => {
    const tempoAtual = +timer.innerHTML;
    timer.innerHTML = tempoAtual + 1;
}, 1000)

// function resetPipePosition(){
//     root.style.setProperty('--animacao1', -80+'px');
//     root.style.setProperty('--animacao2', -70+'px');
// }