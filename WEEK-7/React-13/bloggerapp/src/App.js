import React, { useState } from 'react';
import './App.css';

// Book Details Component
const BookDetails = ({ book }) => {
  return (
    <div className="detail-card">
      <h2>Book Details</h2>
      <h3>{book.title}</h3>
      <p><strong>Author:</strong> {book.author}</p>
      <p><strong>Price:</strong> {book.price}</p>
      <p><strong>Pages:</strong> {book.pages}</p>
    </div>
  );
};

// Blog Details Component  
const BlogDetails = ({ blog }) => {
  return (
    <div className="detail-card">
      <h2>Blog Details</h2>
      <h3>{blog.title}</h3>
      <p><strong>Author:</strong> {blog.author}</p>
      <p><strong>Category:</strong> {blog.category}</p>
      <p><strong>Date:</strong> {blog.date}</p>
    </div>
  );
};

// Course Details Component
const CourseDetails = ({ course }) => {
  return (
    <div className="detail-card">
      <h2>Course Details</h2>
      <h3>{course.title}</h3>
      <p><strong>Instructor:</strong> {course.instructor}</p>
      <p><strong>Duration:</strong> {course.duration}</p>
      <p><strong>Price:</strong> {course.price}</p>
    </div>
  );
};

function App() {
  const [selectedType, setSelectedType] = useState('book');
  const [showDetails, setShowDetails] = useState(true);

 
  const bookData = {
    title: 'Master React',
    author: 'John Doe',
    price: '₹670',
    pages: 450
  };

  const blogData = {
    title: 'Deep Dive into Angular 11',
    author: 'Jane Smith',
    category: 'Web Development',
    date: '2024-01-15'
  };

  const courseData = {
    title: 'Mongo Essentials',
    instructor: 'Prof. Wilson',
    duration: '8 weeks',
    price: '₹450'
  };

  const renderWithIfElse = () => {
    if (selectedType === 'book') {
      return <BookDetails book={bookData} />;
    } else if (selectedType === 'blog') {
      return <BlogDetails blog={blogData} />;
    } else if (selectedType === 'course') {
      return <CourseDetails course={courseData} />;
    }
    return <div>Please select a type</div>;
  };

  const renderWithTernary = () => {
    return selectedType === 'book' ? (
      <BookDetails book={bookData} />
    ) : selectedType === 'blog' ? (
      <BlogDetails blog={blogData} />
    ) : selectedType === 'course' ? (
      <CourseDetails course={courseData} />
    ) : (
      <div>No selection made</div>
    );
  };

  
  const renderWithLogicalAnd = () => {
    return (
      <div>
        {selectedType === 'book' && <BookDetails book={bookData} />}
        {selectedType === 'blog' && <BlogDetails blog={blogData} />}
        {selectedType === 'course' && <CourseDetails course={courseData} />}
      </div>
    );
  };

  const renderWithElementVariable = () => {
    let content;
    
    if (selectedType === 'book') {
      content = <BookDetails book={bookData} />;
    } else if (selectedType === 'blog') {
      content = <BlogDetails blog={blogData} />;
    } else if (selectedType === 'course') {
      content = <CourseDetails course={courseData} />;
    } else {
      content = <div>Select a type to view details</div>;
    }
    
    return content;
  };

  return (
    <div className="App">
      <header className="app-header">
        <h1>Blogger App - Conditional Rendering</h1>
        
        {/* Controls */}
        <div className="controls">
          <button 
            onClick={() => setSelectedType('book')}
            className={selectedType === 'book' ? 'active' : ''}
          >
            Book
          </button>
          <button 
            onClick={() => setSelectedType('blog')}
            className={selectedType === 'blog' ? 'active' : ''}
          >
            Blog
          </button>
          <button 
            onClick={() => setSelectedType('course')}
            className={selectedType === 'course' ? 'active' : ''}
          >
            Course
          </button>
          
          <button onClick={() => setShowDetails(!showDetails)}>
            {showDetails ? 'Hide' : 'Show'} Details
          </button>
        </div>
      </header>

      <main className="main-content">
    
        {showDetails && (
          <>
        
            <section className="method-section">
              <h3>Method 1: If-Else Statement</h3>
              {renderWithIfElse()}
            </section>
         <section className="method-section">
              <h3>Method 2: Ternary Operator</h3>
              {renderWithTernary()}
            </section>

 
            <section className="method-section">
              <h3>Method 3: Logical AND Operator</h3>
              {renderWithLogicalAnd()}
            </section>

          
            <section className="method-section">
              <h3>Method 4: Element Variables</h3>
              {renderWithElementVariable()}
            </section>
          </>
        )}
      </main>
    </div>
  );
}

export default App;
