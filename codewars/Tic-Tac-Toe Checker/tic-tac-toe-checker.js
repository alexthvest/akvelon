function getBoardState(board) {
  board = board.map((x) => x.join("")).join("-");

  if (/222|2...2...2|2....2....2|2..2..2/.test(board)) {
    return 2;
  }

  if (/111|1...1...1|1....1....1|1..1..1/.test(board)) {
    return 1;
  }

  if (/0/.test(board)) {
    return -1;
  }

  return 0;
}

const board = [
  [0, 0, 1],
  [2, 1, 2],
  [1, 0, 0],
];

const boardState = getBoardState(board);
console.log(boardState);
