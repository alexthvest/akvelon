function anagramDifference(w1, w2) {
  const letterCounters = {};

  for (const char of w1) {
    if (char in letterCounters) {
      letterCounters[char]++;
    } else {
      letterCounters[char] = 1;
    }
  }

  for (const char of w2) {
    if (char in letterCounters) {
      letterCounters[char]--;
    } else {
      letterCounters[char] = -1;
    }
  }

  // Sum all counters
  return Object.values(letterCounters).reduce(
    (acc, value) => acc + Math.abs(value),
    0
  );
}

const removeCount = anagramDifference("codewars", "hackerrank");
console.log(removeCount);
