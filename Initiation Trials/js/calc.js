function calc(inStr) {
  const inputError = 'Fatal error: invalid input, not empty string expected',
        unexpectedSymbolError = 'Fatal error: unexpected symbol',
        operandError = 'Fatal error: operand was not found',
        operatorError = 'Fatal error: operator was not found',
        mark = '&';
  if ((typeof(inStr) !== 'string') || (inStr === '')) {  //Если введены неправильные данные, ошибка
    console.log(inputError);
    return;
  }
  
  inStr = processString(inStr); //преобразовать строку вормата '5+6:2*(4+6)-3+' в сторку формата '5&+&6&:&2&*&(4+6)-3'
  if (typeof inStr === 'undefined') {
    console.log(unexpectedSymbolError);
    return;
  }
  let arr = inStr.split(mark); //Преобразовать в массив
  if (arr[0] === ''){  //Если пустая строка 
    console.log(inputError);
    return;
  }
  
  arr = processBrackets(arr); //обработать выражения в скобках (используется рекурсия)
  
  arr = processOperations(arr, '*', '/'); //обработать массив, выполнитв операцции умножения и деления ['1', '+', '3', '*', '5'] => ['1', '+', '15'] лишние элементы удалить  
  if (typeof arr === 'undefined') { //ошибка операнда
    console.log(operandError);
    return;
  }
  
  arr = processOperations(arr, '+', '-'); 
  if (typeof arr === 'undefined') {
    console.log(operandError);
    return;
  }
  
  if (arr.length === 1) { //после обработки должен остаться массив с одним элементом (это ответ), иначе ошибка недостатка операторов
    return arr[0];
  }
  console.log(operatorError);   
  return;    
}

function processString(inStr){ //преобразовать строку вормата '5+6:2*(4+6)-3+' в сторку формата '5&+&6&:&2&*&(4+6)-3'
  const mark = '&'; 
  let outStr = '',
      readingExpressionInBrackets = false,
      bracketCounter = 0,
      i = 0;
  while (inStr[i] === ' ') { //игнорируем первые пробелы
    i++;
  }
  for (i; i < inStr.length; i++){
    
    if (!readingExpressionInBrackets) { //Если в данный момент НЕ читается выражение в скобках
      if (inStr[i] === '+' || inStr[i] === '-' || inStr[i] === '*' || inStr[i] === '/'){  //Если встретил операнд, то поставить маркеры, если нет пробелов
        if (inStr[i - 1] !== ' ') { 
          outStr = outStr + mark;
        }
        outStr = outStr + inStr[i];
        if (inStr[i + 1] !== ' ') {
          outStr = outStr + mark;
        }                                    
      } else if (!isNaN(parseInt(inStr[i]))) { //Если встретил цифру, просто записать
          outStr = outStr + inStr[i];
      } else if (inStr[i] === '(') { //Если встретил скобку, записать её, начать чтение выражения в скобке
          readingExpressionInBrackets = true;
          bracketCounter = 1;
          outStr = outStr + inStr[i];
      } else if (inStr[i] === ' ') {  //Если встретил пробел перед которым нет маркера, то поставить маркер в случае отсутствия других пробелов и выхода за границы массива
          if ( (typeof inStr[i - 1] !== 'undefined') && (inStr[i + 1] !== ' ') && (typeof inStr[i + 1] !== 'undefined') ) {
               outStr = outStr + mark;
             }
      } else {   //Если встретил другой символ то ошибка
          return;
      }
      
    } else { //Если в данный момент читается выражение в скобках
        if (inStr[i] === '(') {     //Считаем скобки и переписываем без изменений
           bracketCounter++;
        } else if (inStr[i] === ')') {
            bracketCounter--;
            if (bracketCounter === 0) {
              readingExpressionInBrackets = false;
            }
        }
        outStr = outStr + inStr[i];       
    }              
  }
  if (bracketCounter !== 0) { //Если есть лишние скобки, то ошибка
    return;
  }
  else {
    return outStr;  //если все ок, возвращаем обработанную строку
  }
}

function processBrackets(arr) { //искать скобку, если нашел, то вычислить выражение в скобках
let tempI;
  for (let i = 0; i < arr.length; i++) {
    tempI = arr[i];
    if (tempI[0] === '(') {
      arr[i] = calc(arr[i].slice(1, -1));
    }
  }     
  return arr;
}

function processOperations(arr, operator1, operator2) {
  for (let i = 0; i < arr.length; i++) {
    if ((arr[i] === operator1) || (arr[i] === operator2)) {
      arr[i - 1] = doOperation(arr[i - 1], arr[i], arr[i + 1]);
      if (typeof arr[i - 1] === 'undefined') return; //если вернул DoOperation значение 
      arr.splice(i, 2); //удалить лишние элементы
      i--; //вычесть 1, чтобы еще раз проверить данный элемент массива 
    }
  }
  return arr;
}

function doOperation(operand1, operator, operand2) {
  if (isNaN(parseInt(operand1))) { //Проверка, являются ли операнды числами, если нет, то ошибка
      return;
  } else if (isNaN(parseInt(operand2))) {
      return;
  }
  switch (operator) {
  case '*':
    return +operand1 * +operand2;
  case '/':
    return +operand1 / +operand2;
  case '+':
    return +operand1 + +operand2;
  case '-':
    return +operand1 - +operand2;
  }
}












