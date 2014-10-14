// Ex. Confirmação
function confirma(obj)
{
var agree=confirm("Você tem certeza que quer apagar este Registro? Tudo referente a ele será excluído!");
if (agree)
location.href=obj;
}
// Ex. de Validação de Formulario
// Não esquecer de no Form colocar  onSubmit="return (Verifica())"
function Verifica() {
var a1 = document.contato.nome.value;
var a2 = document.contato.email.value;
var a3 = document.contato.tel.value;

var ret = 0;
var obj = eval("document.contato.email.value");
  var txt = obj.value;
  if (((txt.length != 0) && (txt.indexOf("@") < 1)) || (txt.indexOf('.') < 7) || (a1 == "") || (a2 == "") || ((a3 == "") && (ret != 1)))
  {
    alert('Preencha os campos corretamente!');
	obj.focus();
	ret = 1;
  }
 
if (ret == 0)  { return true; } else { return false; }

}
// Função de esmaecer
function opacgo(objn) { $(objn).stop(true, true).animate({ opacity: 0.8 }, 100); }
function opacback(objn) { $(objn).stop(true, true).animate({ opacity: 1.0 }, 100); }

//Opacity menu lateral esquerda
function opact(objn) { $(objn).stop(true, true).animate({ opacity: 0.6 }, 100); }
function opactx(objn) { $(objn).stop(true, true).animate({ opacity: 1.0 }, 100); }

//função menu topo
function inicio(){ $('#menuz').stop(true, true).animate({ left: 0, width: 65 }, 700); }
function escola(){ $('#menuz').stop(true, true).animate({ left: 55, width: 80 }, 700); }
function equipe(){ $('#menuz').stop(true, true).animate({ left: 130, width: 105 }, 700); }
function ambiente(){ $('#menuz').stop(true, true).animate({ left: 230, width: 84 }, 700); }
function galeria(){ $('#menuz').stop(true, true).animate({ left: 310, width: 130 }, 700); }
function contato(){ $('#menuz').stop(true, true).animate({ left: 435, width: 78 }, 700); }