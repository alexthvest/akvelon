function sumPairs(ints, s) {
  const numberStorage = new Set();

  for (const number of ints) {
    const requiredNumber = s - number;

    if (numberStorage.has(requiredNumber)) {
      return [requiredNumber, number];
    }

    numberStorage.add(number);
  }

  return undefined;
}

const pair = sumPairs([10, 5, 2, 3, 7, 5], 10);
console.log(pair);
