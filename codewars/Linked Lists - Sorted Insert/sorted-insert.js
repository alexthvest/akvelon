function Node(data) {
  this.data = data;
  this.next = null;
}

function sortedInsert(head, data) {
  const root = new Node();
  const node = new Node(data);

  let current = root;
  current.next = head;

  while (current.next && current.next.data < node.data) {
    current = current.next;
  }

  node.next = current.next;
  current.next = node;

  return root.next;
}
