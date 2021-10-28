var divisor = '--------------------------------------' //Essa variável só foi criada para separar as questões, por uma questão de estética 

// Declarar uma variável qualquer, que receba um objeto vazio.
var qualquer = '';

/*
Declarar uma variável `pessoa`, que receba suas informações pessoais.
As propriedades e tipos de valores para cada propriedade desse objeto devem ser:
- `nome` - String
- `sobrenome` - String
- `sexo` - String
- `idade` - Number
- `altura` - Number
- `peso` - Number
- `andando` - Boolean - recebe "falso" por padrão
- `caminhouQuantosMetros` - Number - recebe "zero" por padrão
*/
var pessoa = new Object();

pessoa.nome = 'Thiago'
pessoa.sobrenome = 'Henrique'
pessoa.sexo = 'Masculino'
pessoa.idade = 16
pessoa.altura = 1.75
pessoa.peso = 50
pessoa.andando = new Boolean(false)
pessoa.caminhouQuantosMetros = 0

console.log(pessoa)

console.log(divisor)

/*
Adicione um método ao objeto `pessoa` chamado `fazerAniversario`. O método deve
alterar o valor da propriedade `idade` dessa pessoa, somando `1` a cada vez que
for chamado.
*/
pessoa.fazerAniversario = function(){
    pessoa.idade += 1
    return pessoa.idade
}

console.log(pessoa.fazerAniversario())

console.log(divisor)

/*
Adicione um método ao objeto `pessoa` chamado `andar`, que terá as seguintes
características:
- Esse método deve receber por parâmetro um valor que representará a quantidade
de metros caminhados;
- Ele deve alterar o valor da propriedade `caminhouQuantosMetros`, somando ao
valor dessa propriedade a quantidade passada por parâmetro;
- Ele deverá modificar o valor da propriedade `andando` para o valor
booleano que representa "verdadeiro";
*/


pessoa.andar = function(mCaminhados){
    pessoa.caminhouQuantosMetros += mCaminhados
    pessoa.andando = true
}

pessoa.andar(7)

console.log(pessoa.caminhouQuantosMetros)
console.log(pessoa.andando)

console.log(divisor)

/*
Adicione um método ao objeto `pessoa` chamado `parar`, que irá modificar o valor
da propriedade `andando` para o valor booleano que representa "falso".
*/
pessoa.parar = function(){
    pessoa.andando = false
}

console.log(pessoa.parar())

console.log(pessoa.andando)

console.log(divisor)

/*
Crie um método chamado `nomeCompleto`, que retorne a frase:
- "Olá! Meu nome é [NOME] [SOBRENOME]!"
*/
pessoa.nomeCompleto = function(){
    return `Olá! Meu nome é ${pessoa.nome} ${pessoa.sobrenome}!`
}

console.log(pessoa.nomeCompleto())

console.log(divisor)

/*
Crie um método chamado `mostrarIdade`, que retorne a frase:
- "Olá, eu tenho [IDADE] anos!"
*/
pessoa.mostrarIdade = function(){
    return `Olá, eu tenho ${pessoa.idade} anos!`
}

console.log(pessoa.mostrarIdade())

console.log(divisor)

/*
Crie um método chamado `mostrarPeso`, que retorne a frase:
- "Eu peso [PESO]Kg."
*/
pessoa.mostrarPeso = function(){
    return `Eu peso ${pessoa.peso}Kg`
}

console.log(pessoa.mostrarPeso())

console.log(divisor)

/*
Crie um método chamado `mostrarAltura` que retorne a frase:
- "Minha altura é [ALTURA]m."
*/
pessoa.mostrarAltura = function(){
    return `Minha altura é ${pessoa.altura}m`
}

console.log(pessoa.mostrarAltura())

console.log(divisor)

/*
Agora vamos brincar um pouco com o objeto criado:
Qual o nome completo da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/

console.log(pessoa.nomeCompleto()) //A função 'nomeCompleto' retorna a junção de 'pessoa.nome' e 'pessoa.sobrenome'

console.log(divisor)

/*
Qual a idade da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/
console.log(pessoa.mostrarIdade()) //A função 'mostrarIdade' retorna a idade da pessoa

console.log(divisor)

/*
Qual o peso da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/
console.log(pessoa.mostrarPeso()) //A função 'mostrarPeso' retorna o peso da pessoa

console.log(divisor)

/*
Qual a altura da pessoa? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/
console.log(pessoa.mostrarAltura()) //A função 'mostrarAltura' retorna a altura da pessoa

console.log(divisor)

/*
Faça a `pessoa` fazer 3 aniversários.
*/
console.log(pessoa.idade)
console.log(pessoa.fazerAniversario())

console.log(pessoa.fazerAniversario())

console.log(pessoa.fazerAniversario())

console.log(divisor)

/*
Quantos anos a `pessoa` tem agora? (Use a instrução para responder e
comentários inline ao lado da instrução para mostrar qual foi a resposta
retornada)
*/
console.log(pessoa.idade)

console.log(divisor)

/*
Agora, faça a `pessoa` caminhar alguns metros, invocando o método `andar` 3x,
com metragens diferentes passadas por parâmetro.
*/
pessoa.andar(10)

pessoa.andar(3)

pessoa.andar(25)

console.log(pessoa.caminhouQuantosMetros)

console.log(divisor)

/*
A pessoa ainda está andando? (Use a instrução para responder e comentários
inline ao lado da instrução para mostrar qual foi a resposta retornada)
*/
console.log(pessoa.andando) //SIM, retornou um 'true'

console.log(divisor)

/*
Se a pessoa ainda está andando, faça-a parar.
*/
pessoa.parar()

console.log(divisor)

/*
E agora: a pessoa ainda está andando? (Use uma instrução para responder e
comentários inline ao lado da instrução para mostrar a resposta retornada)
*/
console.log(pessoa.andando) //NÃO, retornou um 'false'

console.log(divisor)

/*
Quantos metros a pessoa andou? (Use uma instrução para responder e comentários
inline ao lado da instrução para mostrar a resposta retornada)
*/
console.log(pessoa.caminhouQuantosMetros) //A pessoa andou a quantidade de metros que essa variável retornou

console.log(divisor)

/*
Agora vamos deixar a brincadeira um pouco mais divertida! :D
Crie um método para o objeto `pessoa` chamado `apresentacao`. Esse método deve
retornar a string:
- "Olá, eu sou o [NOME COMPLETO], tenho [IDADE] anos, [ALTURA], meu peso é [PESO] e, só hoje, eu já caminhei [CAMINHOU QUANTOS METROS] metros!"
Só que, antes de retornar a string, você vai fazer algumas validações:
- Se o `sexo` de `pessoa` for "Feminino", a frase acima, no início da
apresentação, onde diz "eu sou o", deve mostrar "a" no lugar do "o";
- Se a idade for `1`, a frase acima, na parte que fala da idade, vai mostrar a
palavra "ano" ao invés de "anos", pois é singular;
- Se a quantidade de metros caminhados for igual a `1`, então a palavra que
deve conter no retorno da frase acima é "metro" no lugar de "metros".
- Para cada validação, você irá declarar uma variável localmente (dentro do
método), que será concatenada com a frase de retorno, mostrando a resposta
correta, de acordo com os dados inseridos no objeto.
*/
pessoa.apresentacao = function(){
    if (pessoa.sexo == 'Feminino' && pessoa.idade == 1 && pessoa.caminhouQuantosMetros == 1) {
        return `Olá, eu sou a ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} ano, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metro`
    } 

    if (pessoa.sexo == 'Feminino' && pessoa.idade == 1 && pessoa.caminhouQuantosMetros > 1) {
        return `Olá, eu sou a ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} ano, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metros`
    }

    if (pessoa.sexo == 'Feminino' && pessoa.idade > 1 && pessoa.caminhouQuantosMetros == 1) {
        return `Olá, eu sou a ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} anos, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metro`
    }

    if (pessoa.sexo == 'Feminino' && pessoa.idade > 1 && pessoa.caminhouQuantosMetros > 1) {
        return `Olá, eu sou a ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} anos, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metros`
    }

    if (pessoa.sexo == 'Masculino' && pessoa.idade == 1 && pessoa.caminhouQuantosMetros == 1) {
        return `Olá, eu sou o ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} ano, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metro`
    }
    
    if (pessoa.sexo == 'Masculino' && pessoa.idade == 1 && pessoa.caminhouQuantosMetros > 1) {
        return `Olá, eu sou o ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} ano, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metros`
    }

    if (pessoa.sexo == 'Masculino' && pessoa.idade > 1 && pessoa.caminhouQuantosMetros == 1) {
        return `Olá, eu sou o ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} anos, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metro`
    }
    
    if (pessoa.sexo == 'Masculino' && pessoa.idade > 1 && pessoa.caminhouQuantosMetros > 1) {
        return `Olá, eu sou o ${pessoa.nome} ${pessoa.sobrenome}, tenho ${pessoa.idade} anos, ${pessoa.altura}m, meu peso é de ${pessoa.peso}Kg e, só hoje, eu caminhei ${pessoa.caminhouQuantosMetros} metros`
    }
}

console.log(pessoa.apresentacao())

console.log(divisor)

// Agora, apresente-se ;)
//