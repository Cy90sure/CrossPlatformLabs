import { BrowserRouter as Router, Routes, Route, Navigate, Link } from 'react-router-dom';
import { AuthProvider } from './context/AuthContext'; 
import ProtectedRoute from './context/ProtectedRoute';
import Header from "./pages/Header";
import Profile from "./pages/Profile";
import Login from "./context/Login";
import Logout from "./context/Logout";
import LabPage from './pages/LabPage';

const Home = () => <h1>Welcome to LAB13_React</h1>;
const Lab1 = () => <h1>Lab 1</h1>;
const Lab2 = () => <h1>Lab 2</h1>;
const Lab3 = () => <h1>Lab 3</h1>;

const App = () => {
    return (
        <Router>
            <AuthProvider>
                <div className="d-flex flex-column min-vh-100">
                    <Header />
                    <div className="container flex-grow-1">
                        <main role="main" className="py-4">
                            <Routes>
                                <Route path="/" element={<Home />} />
                                <Route path="/lab1" element={<LabPage labNumber="1" />} />
                                <Route path="/lab2" element={<LabPage labNumber="2" />} />
                                <Route path="/lab3" element={<LabPage labNumber="3" />} />
                                <Route
                                    path="/profile"
                                    element={
                                        <ProtectedRoute>
                                            <Profile />
                                        </ProtectedRoute>
                                    }
                                />
                                <Route path="/login" element={<Login />} />
                                <Route path="/logout" element={<Logout />} />
                                <Route path="*" element={<Navigate to="/" replace />} />
                            </Routes>
                        </main>
                    </div>
                    
                </div>
            </AuthProvider>
        </Router>
    );
};

export default App;