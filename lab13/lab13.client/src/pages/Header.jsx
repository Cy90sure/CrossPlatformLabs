import { Link, useLocation } from 'react-router-dom';
import { useAuth } from '../context/AuthContext';

const Header = () => {
    const { isAuthenticated, user } = useAuth();
    const location = useLocation();

    return (
        <header>
            <nav className="navbar">
                <div className="container">
                    <Link className="btn btn-primary" to="/">lab13</Link>
                    <div className="navbarNav" id="navbarNav">
                        <ul className="navbar-nav me-auto">
                            <li className="nav-item">
                                <Link className={`btn btn-primary ${location.pathname === '/' ? 'active' : ''}`} to="/">Home</Link>
                            </li>
                            <li className="nav-item">
                                <Link className={`btn btn-primary ${location.pathname === '/lab1' ? 'active' : ''}`} to="/lab1">Lab 1</Link>
                            </li>
                            <li className="nav-item">
                                <Link className={`btn btn-primary ${location.pathname === '/lab2' ? 'active' : ''}`} to="/lab2">Lab 2</Link>
                            </li>
                            <li className="nav-item">
                                <Link className={`btn btn-primary ${location.pathname === '/lab3' ? 'active' : ''}`} to="/lab3">Lab 3</Link>
                            </li>
                        </ul>
                        <ul className="navbar-nav">
                            {isAuthenticated ? (
                                <>
                                    <li className="nav-item">
                                        <Link className={`btn btn-primary ${location.pathname === '/profile' ? 'active' : ''}`} to="/profile">
                                            Profile ({user?.name})
                                        </Link>
                                    </li>
                                    <li className="nav-item">
                                        <Link className="btn btn-primary" to="/logout">Logout</Link>
                                    </li>
                                </>
                            ) : (
                                <li className="nav-item">
                                        <Link className={`btn btn-primary ${location.pathname === '/login' ? 'active' : ''}`} to="/login">Login</Link>
                                </li>
                            )}
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    );
};

export default Header;