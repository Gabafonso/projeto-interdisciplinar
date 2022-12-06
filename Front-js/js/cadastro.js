const inputs = document.querySelectorAll('.input');
const button = document.querySelector('.login__button');

const handleFocus = ({ target }) => {
  const span = target.previousElementSibling;
  span.classList.add('span-active');
}

const handleFocusOut = ({ target }) => {
  if (target.value === '') {
    const span = target.previousElementSibling;
    span.classList.remove('span-active');
  }
}

const handleChange = () => {
  const [username, email, password, passwordConfirm, tel] = inputs;

  if (username.value && email.value && password.value.length >= 8 && tel.value.length == 15 && password.value === passwordConfirm.value) {
    button.removeAttribute('disabled');
  } else {
    button.setAttribute('disabled', '');
  }
}

inputs.forEach((input) => input.addEventListener('focus', handleFocus));
inputs.forEach((input) => input.addEventListener('focusout', handleFocusOut));
inputs.forEach((input) => input.addEventListener('input', handleChange));

/* Máscaras ER */
function mascara(o,f){
  v_obj = o //'this' ou 'o', portanto é o document.getElementById('telefone) ou id('telefone')
  v_fun = f //mtel 
  setTimeout("execmascara()",1)
}
function execmascara(){
  v_obj.value = v_fun(v_obj.value) // document.getElementById('telefone).value = mtel(document.getElementById('telefone).value)
}
function mtel(v){
  v = v.replace(/\D/g,""); //Remove tudo o que não é dígito
  v = v.replace(/^(\d{2})(\d)/g,"($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
  v = v.replace(/(\d)(\d{4})$/,"$1-$2"); //Coloca hífen entre o quarto e o quinto dígitos
  return v;
}
function id( el ){
  return document.getElementById( el ); //função para chamar o elemento de um id mais intuitivamente
}
window.onload = function(){
id('telefone').onkeyup = function(){
  mascara( this, mtel );
}
}