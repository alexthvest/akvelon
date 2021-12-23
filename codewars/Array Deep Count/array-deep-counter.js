function deepCount(n) {
  let length = 0;

  for (let i = 0; i < n.length; i++) {
    length += Array.isArray(n[i]) ? deepCount(n[i]) + 1 : 1;
  }

  return length;
}

console.log(deepCount([1, 2, [3, 4, [5]]]));
