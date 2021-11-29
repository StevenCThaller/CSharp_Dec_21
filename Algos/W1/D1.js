/**
 * Class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class Node {
    /**
     * Constructs a new Node instance. Executed when the 'new' keyword is used.
     * @param {any} data The data to be added into this new instance of a Node.
     *    The data can be anything, just like an array can contain strings,
     *    numbers, objects, etc.
     * @returns {Node} A new Node instance is returned automatically without
     *    having to be explicitly written (implicit return).
     */
    constructor(data) {
        this.data = data;
        /**
         * This property is used to link this node to whichever node is next
         * in the list. By default, this new node is not linked to any other
         * nodes, so the setting / updating of this property will happen sometime
         * after this node is created.
         */
        this.next = null;
    }
}

/**
 * Class to represent a list of linked nodes. Nodes CAN be linked together
 * without this class to form a linked list, but this class helps by providing
 * a place to keep track of the start node (head) of the list at all times and
 * as a place to add methods (functions inside an object) so that every new
 * linked list that is instantiated will inherit helpful the same helpful
 * methods, just like every array you create inherits helpful methods.
 */
class SinglyLinkedList {
    /**
     * Constructs a new instance of an empty linked list that inherits all the
     * methods.
     * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
     *    returned without having to explicitly write "return".
     */
    constructor() {
        this.head = null;
    }

    /**
     * Determines if this list is empty.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {boolean}
     */
    isEmpty() {
        // If the head is null, the list is empty, otherwise it's not. Nice and simple?
        return this.head == null;

        // Alternatively:
        if(this.head == null) {
            return true;
        } else {
            return false;
        }
    }

    /**
     * Creates a new node with the given data and inserts it at the back of
     * this list.
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} data The data to be added to the new node.
     * @returns {SinglyLinkedList} This list.
     */
    insertAtBack(data) {
        // Step 1: Create the node we want to add to the back:
        const newNode = new Node(data);

        // Step 2: Check if the list is empty
        if (this.isEmpty()) {
            // Step 2A: If it is, the back is the front, so
            this.head = newNode;
            return this;
        }

        // Step 3: Initialize our runner at the head of the list
        let runner = this.head;

        // Step 4: Initialize our while loop. We want to STOP at the last node,
        // which means STOP the loop when the node runner is referencing has a .next 
        // of null
        while (runner.next) {
            // Step 4A: Set runner to runner.next as long as there is a .next to go to
            runner = runner.next;
        }

        // Step 5: Now that runner is at the last node, set its .next to newNode
        runner.next = newNode;

        return this;
    }

    /**
     * Calls insertAtBack on each item of the given array.
     * - Time: O(n * m) n = list length, m = arr.length.
     * - Space: O(1) constant.
     * @param {Array<any>} vals The data for each new node.
     * @returns {SinglyLinkedList} This list.
     */
    seedFromArr(vals) {
        // Loop through each item in vals
        for (const item of vals) { 
            // call insertAtBackon each of those items
            this.insertAtBack(item);
        }
        return this;

        // alternatively:
        for(var i = 0; i < vals.length; i++) {
            this.insertAtBack(vals[i]);
        }
    }

    /**
     * Converts this list into an array containing the data of each node.
     * - Time: O(n) linear.
     * - Space: O(n).
     * @returns {Array<any>} An array of each node's data.
     */
    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner != null) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }
}

const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().seedFromArr([1]);
const biNodeList = new SinglyLinkedList().seedFromArr([1, 2]);
const firstThreeList = new SinglyLinkedList().seedFromArr([1, 2, 3]);
const secondThreeList = new SinglyLinkedList().seedFromArr([4, 5, 6]);
const unorderedList = new SinglyLinkedList().seedFromArr([
    -5, -10, 4, -3, 6, 1, -7, -2,
]);

const expected1 = [8, 6, 7, 5, 3, 0, 9];
const list1 = new SinglyLinkedList();
list1.seedFromArr([8, 6, 7, 5, 3, 0, 9]);
const result1 = list1.toArr();
console.log(expected1 == result1); // should print: true
