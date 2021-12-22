function mergeArrays(a, b) {
  const mergedArray = [];
  const length = Math.max(a.length, b.length);

  for (let i = 0; i < length; i++) {
    if (i < a.length) {
      mergedArray.push(a[i]);
    }

    if (i < b.length) {
      mergedArray.push(b[i]);
    }
  }

  return mergedArray;
}

const mergedArray = mergeArrays([1, 2, 3], ["a", "b", "c", "d", "e", "f"]);
console.log(mergedArray);
