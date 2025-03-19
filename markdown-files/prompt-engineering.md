# Prompt Engineering Techniques with Examples

## 1. Zero-Shot Prompting
**Definition:**  
Zero-shot prompting involves asking a model to complete a task without providing any examples or prior context.

**Example:**
```
Translate the following sentence into French:  
"I love learning about artificial intelligence."
```
**Expected Output:**
```
J'aime apprendre sur l'intelligence artificielle.
```

---

## 2. One-Shot Prompting
**Definition:**  
One-shot prompting provides the model with a single example before asking it to perform the desired task.

**Example:**
```
Example:  
Translate "I am happy" to French: "Je suis heureux."

Now translate the following sentence into French:  
"I love learning about artificial intelligence."
```
**Expected Output:**
```
J'aime apprendre sur l'intelligence artificielle.
```

---

## 3. Few-Shot Prompting
**Definition:**  
Few-shot prompting gives the model multiple examples to establish a pattern before asking for a response.

**Example:**
```
Translate the following sentences into French:  
1. "I am happy." → "Je suis heureux."  
2. "We are learning." → "Nous apprenons."  
3. "They love music." → "Ils aiment la musique."

Now translate this sentence:  
"I love learning about artificial intelligence."
```
**Expected Output:**
```
J'aime apprendre sur l'intelligence artificielle.
```

---

## 4. Chain-of-Thought (CoT) Prompting
**Definition:**  
Chain-of-Thought prompting encourages the model to reason step-by-step through a problem before providing the final answer.

**Example:**
```
Q: A farmer has 3 fields. Each field has 5 rows of apple trees, and each row contains 10 trees. How many apple trees does the farmer have in total?  

A: Let's break down the problem:  
- The farmer has 3 fields.  
- Each field has 5 rows, which makes 3 * 5 = 15 rows.  
- Each row has 10 trees, giving 15 * 10 = 150 trees in total.  

Therefore, the farmer has 150 apple trees.
```
**Expected Output:**
```
The farmer has 150 apple trees.
```

---

## 5. Chain-of-Thought with Self-Consistency
**Definition:**  
This technique involves running multiple reasoning paths and selecting the most consistent answer to improve accuracy.

**Example:**
```
Q: If a train travels 60 miles per hour for 3 hours, how far does it travel?  

A:  
- Path 1: 60 miles/hour × 3 hours = 180 miles.  
- Path 2: Break down: 60 miles/hour is 1 mile per minute.  
  - 3 hours = 180 minutes → 180 × 1 mile = 180 miles.  

Final answer: 180 miles.
```
**Expected Output:**
```
The train travels 180 miles.
```

---

## 6. Chain of Drafts
**Definition:**  
Chain of Drafts prompts the model to iteratively refine its response by generating an initial draft and then improving upon it.

**Example:**
```
Draft 1:  
Write a brief summary of "The Great Gatsby."  
"The Great Gatsby is a novel about the mysterious millionaire Jay Gatsby and his obsession with Daisy Buchanan."

Draft 2 (Refined):  
"The Great Gatsby explores the life of Jay Gatsby, a wealthy man who throws lavish parties in the hopes of rekindling his romance with Daisy Buchanan, set against the backdrop of 1920s America."

Final Draft:  
"The Great Gatsby, written by F. Scott Fitzgerald, follows the story of Jay Gatsby, a self-made millionaire who seeks to reunite with his lost love, Daisy Buchanan, amidst the decadence of the Jazz Age."
```
**Expected Output:**
```
"The Great Gatsby, written by F. Scott Fitzgerald, follows the story of Jay Gatsby, a self-made millionaire who seeks to reunite with his lost love, Daisy Buchanan, amidst the decadence of the Jazz Age."
```

---

## 7. Self-Ask Prompting
**Definition:**  
Self-Ask prompting encourages the model to ask clarifying questions before arriving at an answer.

**Example:**
```
Q: How many countries are in Africa?  

A: Hmm, I should first clarify if the question is asking about recognized countries by the UN.  
Clarification: Are you asking about UN-recognized countries?  
If yes, the answer is 54 countries recognized by the UN.
```
**Expected Output:**
```
There are 54 countries recognized by the UN in Africa.
```

---

## 8. Tree of Thoughts (ToT)
**Definition:**  
Tree of Thoughts prompts the model to explore different possibilities or paths before converging on a solution.

**Example:**
```
Q: What are some possible strategies to reduce pollution in cities?  

A:  
- Option 1: Promote public transportation to reduce vehicle emissions.  
- Option 2: Implement stricter regulations on industrial pollution.  
- Option 3: Encourage the use of electric vehicles.  
- Option 4: Increase green spaces to absorb carbon dioxide.

Best approach: A combination of promoting public transportation and encouraging electric vehicle adoption.
```
**Expected Output:**
```
A combination of promoting public transportation and encouraging electric vehicle adoption.
```

---

## 9. ReAct (Reasoning + Action)
**Definition:**  
ReAct combines reasoning and action, where the model first reasons about the task and then acts based on the reasoning.

**Example:**
```
Q: Find the capital of France and translate it into Spanish.  

A: Let's break it down:  
- Step 1: The capital of France is Paris.  
- Step 2: Translate "Paris" to Spanish, which remains "París."  

Final answer: París.
```
**Expected Output:**
```
París
```

---

## 10. Retrieval-Augmented Generation (RAG)
**Definition:**  
RAG enhances responses by retrieving relevant data from an external knowledge base before generating an answer.

**Example:**
```
Q: What is the current stock price of Microsoft?  

A:  
- Step 1: Retrieve the latest stock price from a financial database.  
- Step 2: Report the retrieved value.  

Final answer: As of the latest available data, Microsoft's stock price is $X.
```
**Expected Output:**
```
As of the latest available data, Microsoft's stock price is $X.
```

---

## Conclusion
Mastering these prompt engineering techniques helps maximize the performance and reliability of large language models across diverse tasks. Experimenting with different techniques depending on the use case can significantly improve output quality.
