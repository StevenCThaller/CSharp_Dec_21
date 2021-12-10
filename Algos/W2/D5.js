/**
 * Class to represent a stack using an array to store the stacked items.
 * Follows a LIFO (Last In First Out) order where new items are stacked on
 * top (back of array) and removed items are removed from the top / back.
 */
class Stack {
    /**
     * The constructor is executed when instantiating a new Stack() to construct
     * a new instance.
     * @returns {Stack} This new Stack instance is returned without having to
     *    explicitly write 'return' (implicit return).
     */
    constructor() {
        this.items = [];
    }

    /**
     * Adds a new given item to the top / back of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @param {any} item The new item to be added to the top / back.
     * @returns {number} The new length of this stack.
     */
    push(item) {
        // this.items is the array representing our stack, and so we can use the array's
        // built in push command
        this.items.push(item);
        return this.items.length;
    }

    /**
     * Removes the top / last item from this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The removed item or undefined if this stack was empty.
     */
    pop() {
        return this.items.pop();
    }

    /**
     * Retrieves the top / last item from this stack without removing it.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {any} The top / last item of this stack.
     */
    peek() {
        return this.items[this.items.length - 1];
    }

    /**
     * Returns whether or not this stack is empty.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {boolean}
     */
    isEmpty() {
        return this.items.length == 0;
    }

    /**
     * Returns the size of this stack.
     * - Time: O(1) constant.
     * - Space: O(1) constant.
     * @returns {number} The length.
     */
    size() {
        return this.items.length;
    }
}

/**
 * Class to represent a Queue but is implemented using two stacks to store the
 * queued items without using any other objects or arrays to store the items.
 * Retains the FIFO (First in First Out) ordering when adding / removing items.
 */
class TwoStackQueue {
    constructor() {
        this.stack1 = new Stack(); // as the "true queue" (aka this is where the queue items are generally stored)
        this.stack2 = new Stack();
    }

    /**
     * Adds a new item to the back of the queue.
     * - Time: O(n).
     * - Space: O(1).
     * @param {any} item To be added.
     * @returns {number} The new number of items in the queue.
     */
    enqueue(item) { 
        // Back of the queue? More like bottom of the stack!!
        // Steps:
        //  1. Empty stack1 into stack 2
        //  2. Put the new item into stack 1
        //  3. Empty stack2 back into stack1
        while(!this.stack1.isEmpty()) {
            this.stack2.push(this.stack1.pop());
        }

        this.stack1.push(item);

        while(!this.stack2.isEmpty()) {
            this.stack1.push(this.stack2.pop());
        }

        return this.stack1.size();
    }

    /**
     * Removes the next item in the line / queue.
     * - Time: O(1).
     * - Space: O(1).
     * @returns {any} The removed item.
     */
    dequeue() { 
        // Front of the queue? More like top of the stack!!
        return this.stack1.pop();
    }
}