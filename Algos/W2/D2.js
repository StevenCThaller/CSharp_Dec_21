/**
 * Class to represent a queue using an array to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class Queue {
    /**
     * The constructor is executed when instantiating a new Queue() to construct
     * a new instance.
     * @returns {Queue} This new Queue instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the back of the queue and returns the new size of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @param {any} item - The item to be added to the back of the queue
     * @returns {number} The new size of the queue
     */
    enqueue(item) {
        // Push the new item to the back of the array
        this.items.push(item);
        // And return its length
        return this.items.length;
    }

    /**
     * Removes the item from the front of the queue
     * - Time: O(n) - Linear
     * - Space: O(1) - Constant
     * @returns {any} The removed item or undefined if the queue was empty
     */
    dequeue() {
        // This one is much more involved, because even with a built-in,
        // removing an item from anywhere OTHER THAN the back requires
        // us to swap it one at a time to the end. So let's do that

        // i < this.items.length - 1 because we're going to be swapping
        // this.items[i] with this.items[i+1]
        for(var i = 0; i < this.items.length - 1; i++) {
            let temp = this.items[i];
            this.items[i] = this.items[i+1];
            this.items[i+1] = temp;

            // [ this.items[i], this.items[i+1] ] = [ this.items[i+1], this.items[i] ];
        }
        // now, pop off the last item (which was previously the first) and return it
        return this.items.pop();

    }

    /**
     * Returns whether or not this queue is empty
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {boolean} Whether or not the queue is empty
     */
    isEmpty() {
        return this.items.length == 0;
    }

    /**
     * Returns the length of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {number} The length of the queue
     */
    size() {
        return this.items.length;
    }

    /**
     * Retrieves the item at the front of the queue without removing it.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The item at the front of the queue, undefined if empty
     */
    front() {
        return this.items[0];
    }
}

class Node {
    constructor(value) {
        this.data = value;
        this.next = null;
    }
}

/**
 * Class to represent a queue using a Linked List to store the queued items.
 * Follows a FIFO (First In First Out) order where new items are added to the
 * back and items are removed from the front.
 */
class LinkedListQueue {
    /**
     * The constructor is executed when instantiating a new LinkedListQueue() to construct
     * a new instance.
     * @returns {Queue} This new LinkedListQueue instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.head = null;
        // To cut down on time complexity, we can add 2 new properties:
        this.tail = null;
        this.length = 0;
    }

    /**
     * Adds a new given item to the back of the queue and returns the new size of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @param {any} item - The item to be added to the back of the queue
     * @returns {number} The new size of the queue
     */
    enqueue(item) {
        let newItem = new Node(item);
        // EDGE CASE: Empty?
        if(this.isEmpty()) {
            this.head = newItem;
        } else {   // Since we're using a tail, let's set the tail's next node to be our newly created item
            this.tail.next = newItem;
        }
        // Then, set the tail as the new item
        this.tail = newItem;
        // And increment our length before returning it
        this.length++;
        return this.length;
    }

    /**
     * Removes the item from the front of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The removed item or undefined if the queue was empty
     */
    dequeue() {
        // Edge Cases: 
        //  1. Empty queue
        //  2. Only 1 item in the queue
        if(this.isEmpty()) {
            // this is just in case somebody's been messing with our data structure
            this.length = 0;
            // and return undefined
            return undefined;
        } else if(this.length == 1) { // If the queue only contains 1 item
            // hold onto the current head
            let removed = this.head;
            // set both the head and tail to null (because removing the only item means emptying the queue)
            this.head = null;
            this.tail = null;
            // set the length to 0
            this.length = 0;
            // and return the removed item's data
            return removed.data;
        }

        // hold onto the current head before removing it
        let removed = this.head;
        // set the head to the 2nd item
        this.head = removed.next;
        // decrement our length
        this.length--;
        // remove the removed node's reference to any other item
        removed.next = null;
        // and return its data
        return removed.data;
    }

    /**
     * Returns whether or not this queue is empty
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {boolean} Whether or not the queue is empty
     */
    isEmpty() {
        return this.head == null;
    }

    /**
     * Returns the length of the queue
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {number} The length of the queue
     */
    size() {
        return this.length;
    }

    /**
     * Retrieves the item at the front of the queue without removing it.
     * - Time: O(1) - Constant
     * - Space: O(1) - Constant
     * @returns {any} The item at the front of the queue
     */
    front() {
        // Gotta love ternary operators
        return this.head ? this.head.data : undefined;

        // The above line of code is just a shorthand for:
        if(this.head) {
            return this.head.data;
        } else {
            return undefined;
        }
    }
}