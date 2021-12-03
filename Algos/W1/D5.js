class Node {
    constructor(data) {
        this.data = data;
        this.next = null;
    }
}

class SinglyLinkedList {
    constructor() {
        this.head = null;
    }

    seedFromArr(vals) {
        for (const item of vals) {
            this.insertAtBack(item);
        }
        return this;
    }

    toArr() {
        const arr = [];
        let runner = this.head;

        while (runner) {
            arr.push(runner.data);
            runner = runner.next;
        }
        return arr;
    }

    isEmpty() {
        return this.head == null;
    }

    insertAtBack(data) {
        const newNode = new Node(data);
        if (this.isEmpty()) {
            this.head = newNode;
            return this;
        }
        let runner = this.head;
        while (runner.next) {
            runner = runner.next;
        }
        runner.next = newNode;
        return this;
    }

    insertAtFront(data) {
        const newHead = new Node(data);
        newHead.next = this.head;
        this.head = newHead;

        return this;
    }

    removeHead() {
        if (this.isEmpty()) {
            return null;
        }

        const removedHead = this.head;
        this.head = removedHead.next;
        removedHead.next = null;

        return removedHead.data;

    }

    average() {
        let sum = 0;
        let count = 0;
        let runner = this.head;

        while (runner) {
            sum += runner.data;
            count++;
            runner = runner.next;
        }

        return sum / count;
    }

    removeBack() {
        if (this.isEmpty()) {
            return null;
        } else if (this.head.next == null) {
            const removed = this.head;
            this.head = null;
            return removed.data;
        } else {
            let runner = this.head;
            let walker = null;

            while (runner.next) {
                walker = runner;
                runner = runner.next;
            }

            walker.next = null;
            return runner.data;
        }
    }

    contains(val) {
        let runner = this.head;

        while (runner) {
            if (runner.data == val) return true;
            runner = runner.next;
        }
        return false;
    }

    containsRecursive(val, current = this.head) {
        if (current == null) {
            return false;
        } else if (current.data == val) {
            return true;
        } else {
            return this.containsRecursive(val, current.next);
        }
    }

    recursiveMax(runner = this.head, maxNode = this.head) {
        if (runner == null) {
            if (maxNode == null) {
                return null;
            } else {
                return maxNode.data
            }
        }

        if (runner.data > maxNode.data) {
            maxNode = runner;
        }

        return this.recursiveMax(runner.next, maxNode);
    }

    secondToLast() {
        if (this.isEmpty() || this.head.next == null) {
            return null;
        }

        let runner = this.head;
        while (runner.next.next) {
            runner = runner.next;
        }

        return runner.data;
    }

    removeVal(val) {
        if (this.head.data == val) {
            this.removeHead();
            return true;
        }

        let runner = this.head;

        while (runner.next) {
            if (runner.next.data == val) {
                let removed = runner.next;

                runner.next = removed.next;
                removed.next = null;

                return true;
            }

            runner = runner.next;
        }

        return false;
    }

    prepend(newVal, targetVal) {
        if (this.head.data == targetVal) {
            this.insertAtFront(newVal);
            return true;
        }

        let runner = this.head;

        while (runner.next) {
            if (runner.next.data == targetVal) {
                let newNode = new Node(newVal);
                newNode.next = runner.next;
                runner.next = newNode;

                return true;
            }

            runner = runner.next;
        }

        return false;
    }

    /**
     * Concatenates the nodes of a given list onto the back of this list.
     * - Time: O(n) - Linear with relation to the length of this list.
     * - Space: O(1) - Constant, only a runner .
     * @param {SinglyLinkedList} addList An instance of a different list whose
     *    whose nodes will be added to the back of this list.
     * @returns {SinglyLinkedList} This list with the added nodes.
     */
    concat(addList) { 
        // EDGE CASE 1: What if THIS list is empty??
        if(this.isEmpty()) {
            // Well, concatenating a list onto this empty list would be making this list the addList
            this.head = addList.head;
            return this;
        } else if (addList.isEmpty()) { // EDGE CASE 2: What if the OTHER list is empty?
            // If that's the case, there's nothing to concatenate, soooo
            return this;
        }

        // Now that those tricky situations are out of the way, we need to 
        // run to the end of the list, so let's get our runner
        let runner = this.head;

        // To get it to STOP at the last node
        while(runner.next) {
            runner = runner.next;
        }

        // Finally, set the runner (aka the last node) to have a .next of the second
        // list's head
        runner.next = addList.head;

        return this;
    }

    /**
     * Finds the node with the smallest number as data and moves it to the front
     * of this list.
     * - Time: O(?).
     * - Space: O(?).
     * @returns {SinglyLinkedList} This list.
     */
    moveMinToFront() { 
        // EDGE CASE: List is empty or only 1 node
        if(this.isEmpty() || this.head.next == null) {
            return this;
        }

        // To avoid going through the list twice, we'll keep track of both 
        // our "minimum" node and the one before it. To start, let's assume (likely incorrectly)
        // that the head of the list will be the smallest.
        let min = this.head;
        // And what's before the head? Well, nothing.
        let minPrev = null;
        
        // And as always, a runner.
        let runner = this.head;
        // To be able to assign both min AND minPrev when needed, we'll be checking runner's .next
        while(runner.next){
            // Only doing this for readability
            let valueToCheck = runner.next.data;
            // If the node we're checking (runner.next) has data smaller than our current min.data
            if(valueToCheck < min.data) {
                // Set minPrev to the runner and min to runner.next, because min is our new minimum
                minPrev = runner;
                min = runner.next;
            }
            // One way or the other, we still need to move runner
            runner = runner.next;
        }

        // If, after all is said and done, the head WAS the smallest
        if(min == this.head) {
            // Then it's already at the front.
            return this;
        } else { // Otherwise,
            // Ope, gonna scooch right past ya there, bud
            minPrev.next = min.next;
            // Then move the min node so its .next points at the head
            min.next = this.head;
            // But to seal the deal, we need to set that as the new head
            this.head = min;
            return this;
        }
        

    }

    // EXTRA
    /**
     * Splits this list into two lists where the 2nd list starts with the node
     * that has the given value.
     * splitOnVal(5) for the list (1=>3=>5=>2=>4) will change list to (1=>3)
     * and the return value will be a new list containing (5=>2=>4)
     * - Time: O(?).
     * - Space: O(?).
     * @param {any} val The value in the node that the list should be split on.
     * @returns {SinglyLinkedList} The split list containing the nodes that are
     *    no longer in this list.
     */
    splitOnVal(val) { 
        let newList = new SinglyLinkedList();
        if(this.isEmpty()) {
            return newList;
        }

        if(this.head.data == val) {
            newList.head = this.head;
            this.head = null;
            return newList;
        }

        let runner = this.head;

        while(runner.next) {
            if(runner.next.data == val) {
                newList.head = runner.next;
                runner.next = null;
                return newList;
            }

            runner = runner.next;
        }

        return newList;
    }

}
