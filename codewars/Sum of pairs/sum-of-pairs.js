function sumPairs(ints, s) {
  const numberStorage = {};

  for (const number of ints) {
    const requiredNumber = s - number;

    if (requiredNumber in numberStorage) {
      return [requiredNumber, number];
    }

    numberStorage[number] = 1;
  }

  return undefined;
}

const pair = sumPairs([10, 5, 2, 3, 7, 5], 10);
console.log(pair);
