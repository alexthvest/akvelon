function isObject(value) {
  return value !== null && typeof value === "object" && !Array.isArray(value);
}

function flattenMap(map) {
  let flatMap = {};

  for (const key in map) {
    const value = map[key];

    if (isObject(value) === false) {
      flatMap[key] = value;
      continue;
    }

    const nestedMap = flattenMap(value);
    for (const nestedKey in nestedMap) {
      const joinedKey = [key, nestedKey].join("/");
      flatMap[joinedKey] = nestedMap[nestedKey];
    }
  }

  return flatMap;
}

const result = flattenMap({
  a: {
    b: true,
    c: 14.356,
    d: null,
    g: [1, 2, 3],
  },
});

console.log(result);
